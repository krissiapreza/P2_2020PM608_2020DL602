using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020PM608_2020DL602.Models;

namespace P2_2020PM608_2020DL602.Controllers
{
    public class CovidController : Controller
    {
        private readonly parcialDbContext _cxt;

        public CovidController(parcialDbContext mycxt)
        {
            this._cxt = mycxt;
        }


        public IActionResult Index()
        {
            ViewData["titulo"] = "Registro de Covid";

			IEnumerable<Departamentos> datosdp = from d in _cxt.departamentos select d;
			List<SelectListItem> CmbDeptVl = new List<SelectListItem>();
			foreach (Departamentos dept in datosdp)
			{
				SelectListItem mydept = new SelectListItem
				{
					Text = dept.departamento,
					Value = dept.departamentoID.ToString()
				};
				CmbDeptVl.Add(mydept);
			}
			ViewBag.CmbDeptVl = CmbDeptVl;

			IEnumerable<Generos> datosgn = from g in _cxt.generos select g;
			List<SelectListItem> CmbGentVl = new List<SelectListItem>();
			foreach (Generos gen in datosgn)
			{
				SelectListItem mygen = new SelectListItem
				{
					Text = gen.genero,
					Value = gen.generoID.ToString()
				};
				CmbGentVl.Add(mygen);
			}
			ViewBag.CmbGentVl = CmbGentVl;

			IEnumerable<CasosReportados> datos = (from cs in _cxt.casosReportados
													join dp in _cxt.departamentos on cs.departamentoID equals dp.departamentoID
													join gn in _cxt.generos on cs.generoID equals gn.generoID
													select new CasosReportados
													{
														departamento = dp.departamento,
														genero = gn.genero,
														confirmados = cs.confirmados,
														recuperados = cs.recuperados,
														fallecidos = cs.fallecidos,
													}).GroupBy(s => new { s.departamento, s.genero })
												   .Select(g => new CasosReportados
												   {
													   departamento = g.Key.departamento,
													   genero = g.Key.genero,
													   confirmados = g.Sum(x => x.confirmados),
													   recuperados = g.Sum(x => x.recuperados),
													   fallecidos = g.Sum(x => x.fallecidos)
												   }
												   );

			return View(datos);
        }

		public IActionResult agregarCasos(String DeptSel, String GenSel, String cconfir, String nrecu, String nfalle)
        {
			CasosReportados cs = new CasosReportados();

			cs.departamentoID=Convert.ToInt32(DeptSel);
			cs.generoID=Convert.ToInt32(GenSel);
			cs.confirmados=Convert.ToInt32(cconfir);
			cs.recuperados=Convert.ToInt32(nrecu);
			cs.fallecidos=Convert.ToInt32(nfalle);

			_cxt.casosReportados.Add(cs);
			_cxt.SaveChanges();

            return RedirectToAction("Index");
        }


	}
}

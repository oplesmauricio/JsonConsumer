using JsonConsumer.DAO;
using JsonConsumer.Models;
using RestSharp;
using System;
using System.Web.Mvc;

namespace JsonConsumer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Estado estado = null;
            return View(estado);
        }

        public ActionResult InsereDB(Estado model)
        {
            try
            {
                RestClient client = new RestClient("http://services.groupkt.com/state/get/");

                String s = String.Format("{0}/{1}", model.RestResponse.result.country, model.RestResponse.result.abbr);
                RestRequest requisicao = new RestRequest(s);

                IRestResponse<Estado> resposta = client.Execute<Estado>(requisicao);

                Estado estado = resposta.Data;

                EstadoDAO estadoDAO = new EstadoDAO();

                estadoDAO.InserirEstado(estado);
                return View("InsereDB", estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult ConsultaDB(Estado model)
        {
            try
            {
                EstadoDAO estadoDAO = new EstadoDAO();
                Estado estado = new Estado();
                estado = estadoDAO.SelecionarEstado(model);
                return View("ConsultaDB", estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult ConsultaWS(Estado model)
        {
            try
            {
                RestClient client = new RestClient("http://services.groupkt.com/state/get/");
                String s = String.Format("{0}/{1}", model.RestResponse.result.country, model.RestResponse.result.abbr);
                RestRequest requisicao = new RestRequest(s);

                IRestResponse<Estado> resposta = client.Execute<Estado>(requisicao);

                Estado estado = resposta.Data;

                return View(estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
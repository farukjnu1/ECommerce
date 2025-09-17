using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers
{
    public class TransfersController : Controller
    {
        private readonly ITransfer _iTransfer;
        private readonly IProduct _iProduct;
        private readonly IStore _iStore;

        public TransfersController(ITransfer iTransfer, IProduct iProduct, IStore iStore)
        {
            _iTransfer = iTransfer;
            _iProduct = iProduct;
            _iStore = iStore;
        }

        // GET: TransfersController
        public async Task<ActionResult> Index()
        {
            return View(await _iTransfer.GetAll());
        }

        // GET: TransfersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransfersController/Create
        public async Task<ActionResult> Create(int? id)
        {
            try
            {
                var productList = await _iProduct.GetAllProducts();
                var storeList = await _iStore.GetAllStores();

                var products = new List<SelectListItem>();
                foreach (var item in productList)
                {
                    var selec = new SelectListItem();
                    selec.Value = item.ProductId.ToString();
                    selec.Text = item.ProductName;
                    products.Add(selec);
                }

                var stores = new List<SelectListItem>();
                foreach (var item in storeList)
                {
                    var selec = new SelectListItem();
                    selec.Value = item.StoreId.ToString();
                    selec.Text = item.Name;
                    stores.Add(selec);
                }

                var modelVm = new TransferVM();
                if (id != null)
                {
                    var model = await _iTransfer.GetById((int)id);
                    if (model != null)
                    {
                        modelVm = model;
                    }
                }

                modelVm.Products = products;
                modelVm.SourceStores = stores;
                modelVm.DestinationStores = stores;

                return View(modelVm);
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        // POST: TransfersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransferVM modelVm)
        {
            if (ModelState.IsValid)
            {
                if (modelVm.IsApprove == true)
                {
                    ViewBag.ErrorMessage = "Model is not allowed to modify.";
                }
                else
                {
                    try
                    {
                        var model = await _iTransfer.CreateMaster(modelVm);
                        var detailVM = new TransferVM.TransferDetailVM();
                        detailVM.Quantity = modelVm.Quantity;
                        detailVM.SourceStore = modelVm.SourceStore;
                        detailVM.DestinationStore = modelVm.DestinationStore;
                        detailVM.ProductId = modelVm.ProductId;
                        detailVM.TransferId = modelVm.TransferId;
                        await _iTransfer.CreateDetail(detailVM);
                        return RedirectToAction("Create", new { id = model.TransferId });
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = $"Error occurred while saving the purchase: {ex.Message}";
                    }
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Model not valid.";
            }

            if (modelVm.TransferId > 0)
            {
                modelVm = await _iTransfer.GetById(modelVm.TransferId);
            }

            var productList = await _iProduct.GetAllProducts() ?? new List<Product>();
            var storeList = await _iStore.GetAllStores() ?? new List<Store>();
            var products = new List<SelectListItem>();
            foreach (var item in productList)
            {
                var selec = new SelectListItem();
                selec.Value = item.ProductId.ToString();
                selec.Text = item.ProductName;
                products.Add(selec);
            }
            var stores = new List<SelectListItem>();
            foreach (var item in storeList)
            {
                var selec = new SelectListItem();
                selec.Value = item.StoreId.ToString();
                selec.Text = item.Name;
                stores.Add(selec);
            }
            modelVm.Products = products;
            modelVm.SourceStores = stores;
            modelVm.DestinationStores = stores;

            return View(modelVm);
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int? id)
        {
            try
            {

                var modelVm = new TransferVM();
                if (id != null)
                {
                    var model = await _iTransfer.GetById((int)id);
                    if (model != null)
                    {
                        if (model.IsApprove != true)
                        {
                            modelVm = model;
                            await _iTransfer.Approve(modelVm);
                        }
                        else
                        {
                            return Content($"Error: Already approved.");
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        // GET: TransfersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransfersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransfersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransfersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

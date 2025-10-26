using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Web.Components;

public class CatagoriesListViewComponent : ViewComponent
{
    private IStoreRepository _storeRepository;
    public CatagoriesListViewComponent(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public IViewComponentResult Invoke()
    {
        return View(_storeRepository.Products
            .Select(p => p.Category)
            .Distinct()
            .OrderBy(c => c));
    }
}
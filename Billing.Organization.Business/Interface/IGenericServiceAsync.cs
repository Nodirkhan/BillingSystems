using Billing.Organization.Domains.Models;
using System;
using System.Threading.Tasks;

namespace Billing.Organization.Business.Interface
{
    public interface IGenericServiceAsync<TModel> where TModel : class
    {
        Task<HttpResponse<TModel>> GetAll();

        Task<HttpResponse<TModel>> GetById(Guid id);

        Task<HttpResponse<TModel>> GetPageListAsync(int pageNumber, int pageSize);

        Task<HttpResponse<TModel>> Create(TModel model);

        Task<HttpResponse<TModel>> Update(TModel model);

        Task<HttpResponse<TModel>> Delete(Guid Id);
    }
}

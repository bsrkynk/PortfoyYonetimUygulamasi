using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new() //T parametresi sınıf tipinde, ientity tipinde ve newlenebilir olmalıdır.
    {
        //Expression lambda expriession'ı ifade eder.
        Task<T> GetAsync(Expression<Func<T,bool>> predicate);  //x=>x.UserId==1 //tek bir sonuç döner
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //kayıdın önceden var mı yok mu bakılması için
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);  //kayıtların sayısını vs bulmak için 

    }
}

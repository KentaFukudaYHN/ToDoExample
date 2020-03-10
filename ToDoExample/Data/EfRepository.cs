using System.Collections.Generic;
using ToDoExample.Interfaces;
using System.Linq;

namespace ToDoExample.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private ToDoContext _db;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EfRepository(ToDoContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 全件取得
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="entitiy"></param>
        /// <returns></returns>
        public void Regist(T entitiy)
        {
            _db.Add(entitiy);
            _db.SaveChanges();
        }
    }
}

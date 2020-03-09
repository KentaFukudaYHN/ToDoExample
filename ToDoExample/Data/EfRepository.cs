using ToDoExample.Interfaces;

namespace ToDoExample.Data
{
    public class EfRepository<T> : IRepository<T>
    {
        private IDbContext _db;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EfRepository(IDbContext db)
        {
            _db = db;
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

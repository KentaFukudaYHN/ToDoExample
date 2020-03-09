using Moq;
using ToDoExample.Data;
using ToDoExample.Interfaces;
using Xunit;

namespace ToDoExampleTest.Data
{
    /// <summary>
    /// EfRepositoryのテスト
    /// </summary>
    public class EfRepositoryTests
    {
        /// <summary>
        /// 登録テスト
        /// </summary>
        [Fact]
        public void Regist()
        {
            //dbContextのmockを生成
            var dbMock = new Mock<IDbContext>();

            //EfRepositoryのRegistメソッドを実行
            var testEntity = new object();
            var efRepository = new EfRepository<object>(dbMock.Object);
            efRepository.Regist(testEntity);

            //登録メソッドが呼ばれたか確認
            dbMock.Verify(x => x.Add(testEntity));
            dbMock.Verify(x => x.SaveChanges());
        }
    }
}

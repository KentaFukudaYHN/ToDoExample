using System.Collections.Generic;
using Moq;
using ToDoExample.Entities;
using ToDoExample.Interfaces;
using ToDoExample.Services;
using Xunit;

namespace ToDoExampleTest.Services
{
    /// <summary>
    /// ToDoServiceのテスト
    /// </summary>
    public class ToDoServiceTest
    {
        /// <summary>
        /// 一覧取得テスト
        /// </summary>
        [Fact]
        public void GetToDoItems()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoruのGetAllの返り値をnullに設定
            repository.Setup(x => x.GetAll()).Returns((List<ToDoItem>)null);

            //取得処理を実行
            var items = todoService.GetToDoItems();

            //取得処理が呼ばれたか確認
            repository.Verify(x => x.GetAll());

            //取得結果がnullでない事を確認
            Assert.NotEqual(items, null);
        }

        /// <summary>
        /// 新規登録テスト
        /// </summary>
        [Fact]
        public void Regist()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //登録処理を実行
            var entity = new ToDoItem();
            todoService.Regist("title", "content");

            //登録処理が呼ばれたか確認
            repository.Verify(x => x.Regist(It.IsAny<ToDoItem>()));
        }
    }
}

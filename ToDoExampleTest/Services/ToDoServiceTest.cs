using System;
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
        public void GetItemList()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoruのGetAllの返り値を設定
            repository.Setup(x => x.GetAll()).Returns(new List<ToDoItem>());

            //取得処理を実行
            todoService.GetItemList();

            //取得処理が呼ばれたか確認
            repository.Verify(x => x.GetAll());
        }

        /// <summary>
        /// 一覧取得テスト/一覧がnullの場合
        /// </summary>
        [Fact]
        public void GetItemListWithNull()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoruのGetAllの返り値をnullに設定
            repository.Setup(x => x.GetAll()).Returns((List<ToDoItem>)null);

            //取得処理を実行
            var items = todoService.GetItemList();

            //取得処理が呼ばれたか確認
            repository.Verify(x => x.GetAll());

            //取得結果がnullでない事を確認
            Assert.NotEqual(items, null);
        }

        /// <summary>
        /// ToDo詳細テスト
        /// </summary>
        [Fact]
        public void GetItem()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoryの取得処理の設定
            var id = "testId";
            repository.Setup(x => x.GetById(id)).Returns(new ToDoItem());

            //取得処理
            todoService.GetItem(id);

            //取得処理が呼ばれたか確認
            repository.Verify(x => x.GetById(id));
        }

        /// <summary>
        /// ToDo詳細取得テスト/存在しないToDoのID
        /// </summary>
        [Fact]
        public void GetItemWithNotExist()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoryのGetByIdの返り値をnullに設定
            var id = "notExitId";
            repository.Setup(x => x.GetById(id)).Returns((ToDoItem)null);

            //取得処理
            Action getbyIdAction = () => todoService.GetItem(id);

            //ArgumentExceptionの確認
            Assert.Throws<ArgumentException>(getbyIdAction);

            //repositoryの取得処理が呼ばれたか確認
            repository.Verify(x => x.GetById(id));
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

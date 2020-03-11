using System;
using System.Collections.Generic;
using Moq;
using ToDoExample.Entities;
using ToDoExample.Enums;
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
            var id = "testId";
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

        /// <summary>
        /// ToDo完了テスト
        /// </summary>
        [Fact]
        public void Complete()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoryのメソッド設定
            var id = "testId";
            var updateTarget = new ToDoItem();
            repository.Setup(x => x.GetById(id)).Returns(updateTarget);
            repository.Setup(x => x.Update(updateTarget));

            //完了処理を実行
            todoService.Complete(id);

            //repositoryの更新メソッドが実行されたか確認
            updateTarget.State = ToDoState.Complete;
            repository.Verify(x => x.Update(updateTarget));
        }

        /// <summary>
        /// ToDo完了テスト/存在しないToDoの完了
        /// </summary>
        [Fact]
        public void CompleteWithNotExist()
        {
            //repositoryのMockデータを生成
            var repository = new Mock<IRepository<ToDoItem>>();

            //ToDoServiceを生成
            var todoService = new ToDoService(repository.Object);

            //repositoryのメソッド設定
            var id = "testId";
            repository.Setup(x => x.GetById(id)).Returns((ToDoItem)null);
            repository.Setup(x => x.Update(null));

            //ToDo完了
            Action completeAction = () => todoService.Complete(id);

            //ArgumentExeptionの確認
            Assert.Throws<ArgumentException>(completeAction);
        }
    }
}

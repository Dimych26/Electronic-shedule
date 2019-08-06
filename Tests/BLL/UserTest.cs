using BLL.Interfaces;
using BLL.Logic;
using BLL.ModelDTO;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BLL
{
    [TestFixture]
    public class UserTest
    {
        private IUserLogic userService;
        //мокається інтерфейс
        private Mock<IUnitOfWork> uow;
        private Mock<IGenericRepository<User>> userRepository;

        [SetUp]//метод який виконується перед виконуванням тестів
        public void Load()
        {//ств новий обєкт через мок
            uow = new Mock<IUnitOfWork>();
            userRepository = new Mock<IGenericRepository<User>>();
            uow.Setup(x => x.Users).Returns(userRepository.Object);
            uow.Setup(x => x.Users.FindById(It.IsAny<int>())).Returns(
                new User
                {
                    Id = It.IsAny<int>(),
                    Name = It.IsAny<string>(),
                });
            uow.Setup(x => x.Users.FindById(It.IsAny<int>())).Returns(
               new User
               {
                   Name = It.IsAny<string>()
               });
            userService = new UserLogic(uow.Object);
        }

        [Test]//перевіряє добавление що виконується один раз
        public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            UserDTO user = new UserDTO
            {
                Id = It.IsAny<int>(),
                Name = It.IsAny<string>()
            };
            try
            {
                userService.AddUser(user);

                //assert
                uow.Verify(x => x.Users.Create(It.IsAny<User>()), Times.Once);
            }
            catch 
            {
                uow.Verify(x => x.Users.Create(It.IsAny<User>()), Times.Never);
            }
        }



        [Test]//видалення 1 раз
        public void RemoveUser_TryToRemoveUser_RepositoryShouldCallOnce()
        {
            //arrange
            userRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new User
            {
                Id = It.IsAny<int>(),
                Name = It.IsAny<string>()
            });

            //act
            try
            {
                userService.DeleteUser(It.IsAny<int>());

                //assert
                uow.Verify(x => x.Users.Remove(It.IsAny<int>()), Times.Once);
            }
            catch
            {
                uow.Verify(x => x.Users.Remove(It.IsAny<int>()), Times.Never);
            }
        }

        [Test]//отримати всіх один раз
        public void GetAll_RepositoryShouldCallOnce()
        {
            //act
            try
            {
                userService.GetAll();

                //assert
                uow.Verify(x => x.Users.GetAll(), Times.Once);
            }
            catch
            {
                uow.Verify(x => x.Users.GetAll(), Times.Never);
            }
        }

    }
}

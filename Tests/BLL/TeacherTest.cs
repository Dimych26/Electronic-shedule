using BLL.Interfaces;
using BLL.Logic;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelDTO;

namespace Tests.BLL
{
    [TestFixture]
    public class TeacherTest
    {
        private ITeacherLogic teacherService;
        private Mock<IUnitOfWork> uow;
        private Mock<IGenericRepository<Teacher>> teacherRepository;

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            teacherRepository = new Mock<IGenericRepository<Teacher>>();
            uow.Setup(x => x.Teachers).Returns(teacherRepository.Object);
            uow.Setup(x => x.Teachers.FindById(It.IsAny<int>())).Returns(
                new Teacher
                {
                    Id = It.IsAny<int>(),
                    Name = It.IsAny<string>(),
                });
            uow.Setup(x => x.Teachers.FindById(It.IsAny<int>())).Returns(
               new Teacher
               {
                   Name = It.IsAny<string>()
               });
            teacherService = new TeacherLogic(uow.Object);
        }

        [Test]
        public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            var teacher = new TeacherDTO
            {
                Id = It.IsAny<int>(),
                Name = It.IsAny<string>(),
            };

            teacherService.AddTeacher(teacher);

            //assert
            uow.Verify(x => x.Teachers.Create(It.IsAny<Teacher>()), Times.Once);
        }



        [Test]
        public void RemoveTeacher_TryToRemoveTeacher_RepositoryShouldCallOnce()
        {
            //arrange
            teacherRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Teacher
            {
                Id = It.IsAny<int>(),
                Name = It.IsAny<string>()
            });

            //act
            teacherService.DeleteTeacher(It.IsAny<int>());

            //assert
            uow.Verify(x => x.Teachers.Remove(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetAll_RepositoryShouldCallOnce()
        {
            //act
            teacherService.GetAll();

            //assert
            uow.Verify(x => x.Teachers, Times.Once);
        }

        [Test]
        public void GetSheduleGroup_RepositoryShouldCallOnce()
        {
            //act
            teacherService.GetAll();

            //assert
            uow.Verify(x => x.Teachers, Times.Once);
        }

        [Test]
        public void GetTeacher_RepositoryShouldCallOnce()
        {
            //act
            teacherService.GetAll();

            //assert
            uow.Verify(x => x.Teachers, Times.Once);
        }
    }
}

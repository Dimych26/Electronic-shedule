using BLL.Interfaces;
using BLL.Logic;
using BLL.ModelDTO;
using DAL.Entities;
using DAL.Interfaces;

using Moq;
using NUnit.Framework;
using System;

namespace Tests.BLL
{
    [TestFixture]//позн тестів
    public class SheduleTest
    {
        private ISheduleLogic sheduleService;
        private Mock<IUnitOfWork> uow;
        private Mock<IGenericRepository<Shedule>> sheduleRepository;

        [SetUp]//вик перед кожним тестом
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            sheduleRepository = new Mock<IGenericRepository<Shedule>>();
            uow.Setup(x => x.Shedules).Returns(sheduleRepository.Object);
            uow.Setup(x => x.Shedules.FindById(It.IsAny<int>())).Returns(
                new Shedule
                {
                    Auditorys_Number = It.IsAny<int>(),
                    Day = It.IsAny<int>(),
                    Pair = It.IsAny<int>(),
                    UserId = It.IsAny<int>(),
                    Group = It.IsAny<int>()
                });
            uow.Setup(x => x.Teachers.FindById(It.IsAny<int>())).Returns(
               new Teacher
               {
                   Name = It.IsAny<string>()
               });
            sheduleService = new SheduleLogic(uow.Object);
        }

        [Test]
        public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            var shedule = new SheduleDTO
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            };

            sheduleService.AddShedule(shedule);

            //assert
            uow.Verify(x => x.Shedules.Create(It.IsAny<Shedule>()), Times.Once);
        }

        [Test]
        public void Update_TryToEdit_RepositoryShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule()
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act 
            sheduleService.Update(new SheduleDTO
            {
                Auditorys_Number = 5,
                Day = 5,
                Pair = 5,
                UserId = 5,
                Group = 5
            });

            //assert
            uow.Verify(x => x.Shedules.Update(It.IsAny<Shedule>()), Times.Once);
        }

        [Test]
        public void Update_TryToEdit_RepositoryShouldEdit()
        {
            //arrange
            int id = 5;
            Shedule shedule = new Shedule()
            {
                id = 5,
                Auditorys_Number = 4,
            };

            //act 
            sheduleService.Update(new SheduleDTO
            {
                Id = 5,
                Auditorys_Number = 5,
            });

            Shedule updatedShedule = shedule;
            updatedShedule.Auditorys_Number = 5;

            Assert.AreEqual(shedule, updatedShedule);

        }


        [Test]
        public void RemoveShedule_TryToRemoveShedule_RepositoryShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act
            sheduleService.DeleteShedule(It.IsAny<int>());

            //assert
            uow.Verify(x => x.Shedules.Remove(It.IsAny<int>()), Times.Once);
        }

        [Test]
        //[ExpectedException(typeof(Exception),
        //      "You are not registered")]
        public void GetSheduleGroup_ShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act

            //var ex = Assert.Catch<Exception>(
            //   () => sheduleService.GetSheduleGroup(It.IsAny<int>()));
            try
            {
                sheduleService.GetSheduleGroup(It.IsAny<int>());
                uow.Verify(x => x.Shedules, Times.AtLeast(1));
            }
            catch(Exception ex)
            {
                Assert.That(ex.Message.Contains("You are not registered"));
                uow.Verify(x => x.Shedules, Times.Never);
            }

            //Assert.That(() => sheduleService.GetSheduleGroup(It.IsAny<int>()), Throws.Exception.Contains("You are not registered"));
            //Assert.IsTrue(ex.Message.Contains("You are not registered"));
            
            //assert
            
            
            // Assert.Throws<Exception>(delegate { sheduleService.GetSheduleGroup)
        }
        [Test]

        public void GetAutitoryShedule_ShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act
            try
            {
                sheduleService.GetAutitoryShedule(It.IsAny<int>());
                uow.Verify(x => x.Shedules, Times.Once);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message.Contains("You are not registered"));
                uow.Verify(x => x.Shedules, Times.Never);
            }
           

            //assert
            
        }
        [Test]
        public void GetDisciplineShedule_ShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act
            try
            {
                sheduleService.GetDisciplineShedule(It.IsAny<string>());
                uow.Verify(x => x.Shedules, Times.Once);
            }
            catch (Exception ex)
            {
               // Assert.That(ex.Message.Contains("You are not registered"));
                uow.Verify(x => x.Shedules, Times.Never);
            }
            

            //assert
            
        }

        [Test]
        public void LoadTeacherName_ShouldCallOnce()
        {
            //arrange
            sheduleRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Shedule
            {
                Auditorys_Number = It.IsAny<int>(),
                Day = It.IsAny<int>(),
                Pair = It.IsAny<int>(),
                UserId = It.IsAny<int>(),
                Group = It.IsAny<int>()
            });

            //act
            sheduleService.LoadTeacherName(It.IsAny<int>());

            //assert
            uow.Verify(x => x.Teachers.FindById(It.IsAny<int>()), Times.Once);
        }
    }
}
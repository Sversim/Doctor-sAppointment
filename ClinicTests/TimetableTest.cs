using Domain;
using Moq;
using MyFirstClassLibrary;

namespace ClinicTests
{
    public class TimetableTest
    {
        private readonly TimetableInteractor _timetableInteractor;
        private readonly Mock<ITimetableRepository> _timetableRepositoryMock;

        public TimetableTest()
        {
            _timetableRepositoryMock = new Mock<ITimetableRepository>();
            _timetableInteractor = new TimetableInteractor(_timetableRepositoryMock.Object);
        }

        [Fact]
        public void GetTimetable_Fail()
        {
            _timetableRepositoryMock.Setup(repository => repository.GetMedicsTimetable(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(() => null);
            var res = _timetableInteractor.GetTimetable(It.IsAny<int>(), It.IsAny<DateTime>());
            Assert.True(res.IsFailure);
        }

        [Fact]
        public void GetTimetable_Ok()
        {
            _timetableRepositoryMock.Setup(repository => repository.GetMedicsTimetable(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(() => new Timetable());
            var res = _timetableInteractor.GetTimetable(It.IsAny<int>(), It.IsAny<DateTime>());
            Assert.True(res.Success);
        }

        [Fact]
        public void SetMedicsTimetable_Fail()
        {
            _timetableRepositoryMock.Setup(repository => repository.SetMedicsTimetable(It.IsAny<int>(), It.IsAny<Timetable>())).Returns(() => false);
            var res = _timetableInteractor.SetTimetable(It.IsAny<int>(), It.IsAny<Timetable>());
            Assert.True(res.IsFailure);
        }

        [Fact]
        public void SetMedicsTimetable_Ok()
        {
            _timetableRepositoryMock.Setup(repository => repository.SetMedicsTimetable(It.IsAny<int>(), It.IsAny<Timetable>())).Returns(() => true);
            var res = _timetableInteractor.SetTimetable(It.IsAny<int>(), It.IsAny<Timetable>());
            Assert.True(res.Success);
        }
    }
}

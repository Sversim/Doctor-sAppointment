using Domain;
using Moq;
using MyFirstClassLibrary;

namespace ClinicTests
{
    public class AppointmentTests
    {
        private readonly AppointmentInteractor _appointmentInteractor;
        private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;

        public AppointmentTests()
        {
            _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            _appointmentInteractor = new AppointmentInteractor(_appointmentRepositoryMock.Object);
        }


        [Fact]
        public void SetAppointment_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.SetAppointment(It.IsAny<DateTime>(), It.IsAny<int?>())).Returns(() => false);
            var res = _appointmentInteractor.ScheduleAnAppointment(It.IsAny<DateTime>(), It.IsAny<int?>());

            Assert.True(res.IsFailure);
        }

        [Fact]
        public void AppointmentAlreadyExists_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.IsAppointmentExists(It.IsAny<DateTime>(), It.IsAny<int?>())).Returns(() => true);
            var res = _appointmentInteractor.ScheduleAnAppointment(It.IsAny<DateTime>(), It.IsAny<int?>());

            Assert.True(res.IsFailure);
        }

        [Fact]
        public void SetAppointment_Ok()
        {
            _appointmentRepositoryMock.Setup(repository => repository.SetAppointment(It.IsAny<DateTime>(), It.IsAny<int?>())).Returns(() => true);
            var res = _appointmentInteractor.ScheduleAnAppointment(It.IsAny<DateTime>(), It.IsAny<int?>());

            Assert.True(res.Success);
        }


        [Fact]
        public void GetFreeTime_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.GetTimeBySpec(It.IsAny<Specialization>())).Returns(() => new List<DateOnly> {});
            var res = _appointmentInteractor.GetFreeTime(It.IsAny<Specialization>());

            Assert.True(res.IsFailure);
        }

        [Fact]
        public void GetFreeTime_Ok()
        {
            _appointmentRepositoryMock.Setup(repository => repository.GetTimeBySpec(It.IsAny<Specialization>())).Returns(() => new List<DateOnly> { new DateOnly() });
            var res = _appointmentInteractor.GetFreeTime(It.IsAny<Specialization>());

            Assert.True(res.Success);
        }
    }
}

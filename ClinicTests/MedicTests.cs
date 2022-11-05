using Domain;
using Moq;
using MyFirstClassLibrary;

namespace ClinicTests
{
    public class MedicTests
    {
        private readonly MedicInteractor _medicInteractor;
        private readonly Mock<IMedicRepository> _medicRepositoryMock;

        public MedicTests()
        {
            _medicRepositoryMock = new Mock<IMedicRepository>();
            _medicInteractor = new MedicInteractor(_medicRepositoryMock.Object);
        }

        //Добавление
        [Fact]
        public void MedicAlreadyExcist_Fail()
        {
            int exampleId = 1;
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => new Medic());
            var res = _medicInteractor.AddANewMedic(exampleId, "", new Specialization());

            Assert.True(res.IsFailure);
            Assert.Equal("Врач с таким идентификатором уже существует", res.Error);
        }

        [Fact]
        public void MedicWasntAdded_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            _medicRepositoryMock.Setup(repository => repository.AddMedicWithParameters(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Specialization>()))
                .Returns(() => null);

            var res = _medicInteractor.AddANewMedic(1, "Lorem", new Specialization());

            Assert.True(res.IsFailure);
            Assert.Equal("Врач не добавлен", res.Error);
        }

        [Fact]
        public void EmptyName_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            _medicRepositoryMock.Setup(repository => repository.AddMedicWithParameters(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Specialization>()))
                .Returns(() => new Medic());

            var res = _medicInteractor.AddANewMedic(1, "", new Specialization());

            Assert.True(res.IsFailure);
            Assert.Equal("Имя не должно быть пустым", res.Error);
        }

        [Fact]
        public void MedicWasAdded_Ok()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            _medicRepositoryMock.Setup(repository => repository.AddMedicWithParameters(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Specialization>()))
                .Returns(() => new Medic());

            var res = _medicInteractor.AddANewMedic(1, "Lorem", new Specialization());
            Assert.True(res.Success);
        }

        //Удаление
        [Fact]
        public void MedicCannotBeDeleted_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            var res = _medicInteractor.DeleteMedic(It.IsAny<int>());

            Assert.True(res.IsFailure);
            Assert.Equal("Удаляемого объекта не существует", res.Error);
        }

        [Fact]
        public void UnexpectedErrorWithDeleting_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => new Medic());
            _medicRepositoryMock.Setup(repository => repository.DeleteMedicWithId(It.IsAny<int>())).Returns(() => false);
            var res = _medicInteractor.DeleteMedic(It.IsAny<int>());

            Assert.True(res.IsFailure);
            Assert.Equal("При удалении произошла ошибка", res.Error);
        }

        [Fact]
        public void succesDeleting_Ok()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => new Medic());
            _medicRepositoryMock.Setup(repository => repository.DeleteMedicWithId(It.IsAny<int>())).Returns(() => true);
            var res = _medicInteractor.DeleteMedic(It.IsAny<int>());

            Assert.True(res.Success);
        }

        //Поиск
        [Fact]
        public void NullWhenSearchById_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            var res = _medicInteractor.SearchForAMedic(It.IsAny<int>());

            Assert.True(res.IsFailure);
            Assert.Equal("Врач не найден", res.Error);
        }

        [Fact]
        public void NullWhenSearchBySpec_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => null);
            var res = _medicInteractor.SearchForAMedic(It.IsAny<Specialization>());

            Assert.True(res.IsFailure);
            Assert.Equal("Ни один врач не найден", res.Error);
        }

        [Fact]
        public void SearchByIdSuccess_Ok()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicWithId(It.IsAny<int>())).Returns(() => new Medic());
            var res = _medicInteractor.SearchForAMedic(It.IsAny<int>());

            Assert.True(res.Success);
        }

        [Fact]
        public void SearchBySpecSuccess_Ok()
        {
            _medicRepositoryMock.Setup(repository => repository.SearchForAMedicsWithSpecialization(It.IsAny<Specialization>())).Returns(() => new List<Medic> { new Medic() });
            var res = _medicInteractor.SearchForAMedic(It.IsAny<Specialization>());

            Assert.True(res.Success);
        }

        //Получение списка
        [Fact]
        public void GetAll_Fail()
        {
            _medicRepositoryMock.Setup(repository => repository.GetAllMedics()).Returns(() => null);
            var res = _medicInteractor.AllOfMedics();

            Assert.True(res.IsFailure);
            Assert.Equal("Ни один врач не найден", res.Error);
        }

        [Fact]
        public void GetAll_Ok()
        {
            _medicRepositoryMock.Setup(repository => repository.GetAllMedics()).Returns(() => new List<Medic> {new Medic()});
            var res = _medicInteractor.AllOfMedics();

            Assert.True(res.Success);
        }
    }
}

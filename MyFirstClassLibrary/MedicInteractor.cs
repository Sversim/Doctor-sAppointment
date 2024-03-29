﻿using MyFirstClassLibrary;

namespace Domain
{
    public class MedicInteractor
    {
        private readonly IMedicRepository _repository;
        public MedicInteractor(IMedicRepository repository)
        {
            _repository = repository;
        }


        public Result<Medic> AddANewMedic(int id, string fullName, Specialization specialization)
        {
            if (_repository.SearchForAMedicWithId(id) is not null)
            {
                return Result.Fail<Medic>("Врач с таким идентификатором уже существует");
            }
            if (string.IsNullOrEmpty(fullName))
            {
                return Result.Fail<Medic>("Имя не должно быть пустым");
            }
            Medic? medic = _repository.AddMedicWithParameters(id, fullName, specialization);
            return medic is null ? Result.Fail<Medic>("Врач не добавлен") : Result.Ok(medic);
        }

        public Result<bool> DeleteMedic(int id)
        {
            if (_repository.SearchForAMedicWithId(id) is null)
            {
                return Result.Fail<bool>("Удаляемого объекта не существует");
            }
            return _repository.DeleteMedicWithId(id) ? Result.Ok(true) : Result.Fail<bool>("При удалении произошла ошибка");
        }

        public Result<Medic> SearchForAMedic(int id) 
        {
            Medic? medic = _repository.SearchForAMedicWithId(id);
            return medic is null ? Result.Fail<Medic>("Врач не найден") : Result.Ok(medic);
        }

        public Result<List<Medic>> SearchForAMedic(Specialization specialization)
        {
            List<Medic>? medics = _repository.SearchForAMedicsWithSpecialization(specialization);
            return medics?.Any() ?? false ? Result.Ok(medics) : Result.Fail<List<Medic>>("Ни один врач не найден");
        }

        public Result<List<Medic>> AllOfMedics()
        {
            List<Medic>? medics = _repository.GetAllMedics();
            return medics?.Any() ?? false ? Result.Ok(medics) : Result.Fail<List<Medic>>("Ни один врач не найден");
        }

    }
}

﻿using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public static class UserModelToDomainConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User(model.Id, model.Password, model.FullName, model.FullName, model.Password, model.UserRole);
        }
    }
}

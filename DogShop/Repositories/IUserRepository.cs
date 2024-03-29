﻿using DogShop.Models;


namespace DogShop.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User FindByEmail(string email);

    }
}

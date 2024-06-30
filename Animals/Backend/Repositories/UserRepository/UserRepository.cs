﻿using Backend.Models.UserModels;
using Backend.Repositories.Interface.IRepositoryUser;

namespace Backend.Repositories.UserRepository.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<User> IUserRepository.GetUserByProfileId(int profileId)
        {
            return GetAll().Where(m => m.ProfileId == profileId);
        }

        IEnumerable<User> IUserRepository.GetUserByAssociationId(int associationId)
        {
            return GetAll().Where(m => m.AssociationId == associationId);
        }
    }
}

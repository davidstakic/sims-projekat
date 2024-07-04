﻿using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Repositories.PostRepositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(string filePath) : base(filePath)
        {
        }

        public IEnumerable<Post> GetPostByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId);
        }

        IEnumerable<Post> IPostRepository.GetPostByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }
    }
}

﻿using Backend.Models.Enums;

namespace Backend.Models.UserModels
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int ProfileId { get; set; }
        public int AssociationId { get; set; }

        public User() { }
        public User(int id, string firstName, string lastName, string phoneNumber, string email, DateOnly birthDate, Gender gender, int profileId, int associationId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            ProfileId = profileId;
            AssociationId = associationId;
        }
    }
}

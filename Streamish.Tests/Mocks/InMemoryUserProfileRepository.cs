using Streamish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamish.Tests.Mocks
{
    class InMemoryUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile video)
        {
            var lastUserProfile = _data.Last();
            video.Id = lastUserProfile.Id + 1;
            _data.Add(video);
        }

        public void Delete(int id)
        {
            var videoToDelete = _data.FirstOrDefault(p => p.Id == id);
            if (videoToDelete == null)
            {
                return;
            }

            _data.Remove(videoToDelete);
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void Update(UserProfile video)
        {
            var currentUserProfile = _data.FirstOrDefault(p => p.Id == video.Id);
            if (currentUserProfile == null)
            {
                return;
            }

            currentUserProfile.Description = video.Description;
            currentUserProfile.Title = video.Title;
            currentUserProfile.DateCreated = video.DateCreated;
            currentUserProfile.Url = video.Url;
            currentUserProfile.UserProfileId = video.UserProfileId;
        }

        public List<UserProfile> Search(string criterion, bool sortDescending)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetAllWithComments()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileByIdWithComments(int id)
        {
            throw new NotImplementedException();
        }
    }
}

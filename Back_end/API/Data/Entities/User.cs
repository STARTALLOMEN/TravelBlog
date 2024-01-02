using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public enum enumStatus{
        Deleted = 0,
        Active = 1
    }
    public enum enumGender{
        Male = 0,
        Female = 1
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public string? ImageCover { get; set; }
        public enumGender Gender { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? Logitude { get; set; }
        public string? Latitude { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int RoleId{ get; set; }
        public Role Role{ get; set; }
        //public List<BookmarkUser> BookmarkUsers { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<News> News { get; set; }
        public List<ReviewDestination> ReviewDestinations { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Question> Questions { get; set; }
        public List<Like> Likes { get; set; }
        public List<Plan> Plans{ get; set; }
        public List<Blog> Blogs{ get; set; }

    }
}
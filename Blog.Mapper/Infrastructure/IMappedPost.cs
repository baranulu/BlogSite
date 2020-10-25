using System;
using System.Collections.Generic;
using Blog.Mapper.ViewModels.PostViewModels;

namespace Blog.Mapper.Infrastructure
{
    public interface IMappedPost 
    {
        IEnumerable<PostIndexVM> GetAllMappedPosts();
        void AddMappedPost(PostCreateVM vm, Guid[] categories);
        void UpdateMappedPost(PostEditVM vm);
        PostEditVM GetMappedPost(Guid id);
        void DeleteMappedPost(PostDeleteVM vm);
        PostDeleteVM GetDeletePost(Guid id);
        PostDetailVM GetDetailMappedPost(Guid id);
        int Save();
    }
}

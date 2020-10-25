using System;
using System.Collections.Generic;
using Blog.Mapper.Infrastructure;
using Blog.Mapper.ViewModels.PostViewModels;
using AutoMapper;
using Blog.Business.Repositories;
using Blog.Entities.Models;

namespace Blog.Mapper.Repositories
{
    public class MappedPost : IMappedPost
    {
        private readonly IPostRepository _postRepository;
        private IMapper _mapper;
        public MappedPost(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }

        public IEnumerable<PostIndexVM> GetAllMappedPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<List<PostIndexVM>>(posts);
        }

        public void AddMappedPost(PostCreateVM vm, Guid[] categories)
        {
            Post post = _mapper.Map<Post>(vm);
            _postRepository.Add(post, categories);

        }















        public void DeleteMappedPost(PostDeleteVM vm)
        {
            throw new NotImplementedException();
        }

        public PostDeleteVM GetDeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public PostDetailVM GetDetailMappedPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public PostEditVM GetMappedPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return _postRepository.Save();
        }

        public void UpdateMappedPost(PostEditVM vm)
        {
            throw new NotImplementedException();
        }
    }
}







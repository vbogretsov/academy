﻿using System;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    public class CommentController : AcademyController
    {
        [HttpGet]
        public ActionResult GetUserComments(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var page = LoadUserComments(CurrentUser.Id, pageNumber, pageSize);
            return View("SingleCommentsPageView", page);
        }

        [HttpGet]
        public ActionResult GetArticleComments(
            int articleId,
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var page = LoadArticleComments(articleId, pageNumber, pageSize);
            return View("CommentsPageView", page);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveComment(int commentId)
        {
            Service.RemoveComment(commentId);
            return null;
        }

        [HttpPost]
        public ActionResult CommentArticle(CommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Comment(CommentMapper.Map(viewModel));
            }
            return GetArticleComments(viewModel.ArticleId);
        }

        private PageDataViewModel<CommentViewModel> LoadArticleComments(
            int articleId,
            int pageNumber,
            int pageSize)
        {
            var comments = Service.GetArticleComments(articleId, pageNumber, pageSize);
            var page = PageDataMapper.Map(comments, CommentMapper.Map);
            page.UrlFormat = String.Format("#/GetArticleComments?articleId={0}&", articleId);
            return page;
        }

        private PageDataViewModel<CommentViewModel> LoadUserComments(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var comments = Service.GetUserComments(userId, pageNumber, pageSize);
            var page = PageDataMapper.Map(comments, SingleCommentMapper.Map);
            page.AreaId = "userComments";
            page.UrlFormat = "#/GetUserComments?";
            return page;
        }
    }
}
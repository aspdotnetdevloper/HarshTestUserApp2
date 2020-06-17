using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HarshTestUserApp.Models;
using HarshTestUserApp.Repository;
using AutoMapper;

namespace HarshTestUserApp.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Index()
        {
            try
            {
                UnitOfWorkProvider _unitOfWork = new UnitOfWorkProvider();
                var userList = _unitOfWork.UserRepository.GetAll().ToList();
                List<UserViewModel> userViewModelList = Mapper.Map<List<tblUser>, List<UserViewModel>>(userList);
                if (TempData["Message"] != null)
                {
                    ViewBag.Message = Convert.ToString(TempData["Message"]);
                }
                return View(userViewModelList);
            }
            catch (Exception ex)
            {
                Logger.GetInstance.WriteToFileOrSendEmail(ex);
                throw ex;
            }
            
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                UnitOfWorkProvider _unitOfWork = new UnitOfWorkProvider();
                var tblUser = _unitOfWork.UserRepository.GetById(id);
                var userViewModel = Mapper.Map<tblUser, UserViewModel>(tblUser);
                return View(userViewModel);
            }
            catch (Exception ex)
            {
                Logger.GetInstance.WriteToFileOrSendEmail(ex);
                throw ex;
            }
        }

        // GET: User/Create
        public ActionResult CreateEdit(int? id = 0)
        {
            try
            {
                if (id > 0)
                {
                    UnitOfWorkProvider _unitOfWork = new UnitOfWorkProvider();
                    var tblUser = _unitOfWork.UserRepository.GetById(id);
                    var userViewModel = Mapper.Map<tblUser, UserViewModel>(tblUser);
                    return View(userViewModel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.WriteToFileOrSendEmail(ex);
                throw ex;
            }

        }

        // POST: User/Create
        [HttpPost]
        public ActionResult CreateEdit(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UnitOfWorkProvider _unitOfWork = new UnitOfWorkProvider();
                    var tblUser = Mapper.Map<UserViewModel, tblUser>(userViewModel);
                    if (tblUser.UserId > 0)
                    {
                        _unitOfWork.UserRepository.Update(tblUser);
                        TempData["Message"] = "User updated successfully.";
                    }
                    else
                    {
                        _unitOfWork.UserRepository.Insert(tblUser);
                        TempData["Message"] = "User created successfully.";
                    }
                    _unitOfWork.UserRepository.Save();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(userViewModel);
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.WriteToFileOrSendEmail(ex);
                throw ex;
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UnitOfWorkProvider _unitOfWork = new UnitOfWorkProvider();
                _unitOfWork.UserRepository.Delete(id);
                _unitOfWork.UserRepository.Save();
                TempData["Message"] = "User deleted successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.GetInstance.WriteToFileOrSendEmail(ex);
                throw ex;
            }
        }
    }
}

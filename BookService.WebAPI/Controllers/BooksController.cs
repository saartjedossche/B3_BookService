﻿using BookService.WebAPI.DTO;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BookService.WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository repository;

        public BooksController(BookRepository bookRepository)
        {
            repository = bookRepository;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(repository.List());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBookBasic()
        {
            return Ok(repository.ListBasic());
        }

        // GET: api/Books/3
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(repository.GetById(id));
        }

        // GET: api/books/imagebyname/book2.jpg
        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // GET: api/books/imagebyid/6
        [HttpGet]
        [Route("ImageById/{bookid}")]
        public IActionResult ImageById(int bookid)
        {
            BookDetail book = repository.GetById(bookid);
            return ImageByFileName(book.FileName);
        }

    }
}
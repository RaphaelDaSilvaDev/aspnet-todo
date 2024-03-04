using asp_todo.Contexts;
using asp_todo.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_todo.Controllers;

public class TodoController : Controller{

  private readonly TodoContext _context;

  public TodoController(TodoContext context){
    _context = context;
  }

  public IActionResult Index(){
    ViewData["Title"] = "Todo List";
    var todos = _context.Todos.ToList();
    return View(todos);
  }

  public IActionResult Create(){
    ViewData["Title"] = "Create Task";
    return View("Form");
  }

  [HttpPost]
  public IActionResult Create(Todo todo){
    if(ModelState.IsValid){
      _context.Todos.Add(todo);
     _context.SaveChanges();
     return RedirectToAction(nameof(Index));
    }else{
       ViewData["Title"] = "Create Task";
      return View("Form");
    }
   
  }

  public IActionResult Edit(int id){
    ViewData["Title"] = "Edit Task";
    var todo = _context.Todos.Find(id);
    if(todo is null){
      return NotFound();
    }
    return View("Form",  todo);
  }

  [HttpPost]
  public IActionResult Edit(Todo todo){
    if(ModelState.IsValid){
      _context.Todos.Update(todo);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }else{
      ViewData["Title"] = "Edit Task";
      return View("Form",  todo);
    }
   
  }

    public IActionResult Delete(int id){
    ViewData["Title"] = "Delete Todo"; 
    var todo = _context.Todos.Find(id);
    if(todo is null){
      return NotFound();
    }
    return View(todo);
  }

  [HttpPost]
  public IActionResult Delete(Todo todo){
    _context.Todos.Remove(todo);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
  }

  public IActionResult Finish(int id){
    var todo = _context.Todos.Find(id);
    if(todo is null){
      return NotFound();
    }
    todo.Finish();
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
  }
}
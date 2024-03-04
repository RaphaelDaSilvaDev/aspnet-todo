using System.ComponentModel.DataAnnotations;

namespace asp_todo.Validators;

public class FutureOrPresentAttribute : ValidationAttribute{
  public FutureOrPresentAttribute(){
    ErrorMessage = "The field {0} musb be a future or present date!";
  }

    public override bool IsValid(object? value)
    {
      if(value is null || value.Equals("")){
        return true; 
      }

      var date = (DateOnly)value;
      return date >= DateOnly.FromDateTime(DateTime.Now);
    }
}
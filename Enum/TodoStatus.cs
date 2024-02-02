using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Enum
{

    public enum TodoStatus
    {


        [Display(Name = "A faire")]
        A_FAIRE,

        [Display(Name = "Terminée")]
        TERMINEE,
    }
}

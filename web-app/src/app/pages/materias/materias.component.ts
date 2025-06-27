import { Component, effect, inject,signal,Signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaService } from '../../services/materia.service';
import { usuario } from '../../store/auth-store';
import { FormBuilder as fb, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-materias',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './materias.component.html',
  styleUrl: './materias.component.css'
})
export class MateriasComponent {
   private _http = inject(MateriaService);
   private fb=inject(fb);
  formData=this.fb.group({
     idEstudiante: new FormControl(0, [Validators.required]),
     idMateriasProfesores:new FormControl('',[Validators.required])
  })

   materias=signal<any>([]);

   res=effect(() => {
     this._http.getMaterias().subscribe({
       next: (res) => {
         console.log(res);
         this.materias.set(res.data);
       },
       error: (error) => {
         console.error('Error al obtener las materias:', error);
       }
     });
   });

   postMateria(){
      const u=usuario();
      this.formData.patchValue({ idEstudiante: u?.id });
      console.log(this.formData.value)
      this._http.postMateria(this.formData.value).subscribe({
        next:(res)=>{
          alert(res.mensaje)
        },
        error: (error) => {
          alert(error.error?.mensaje)
          console.error('Error al obtener las clases:', error);
        }
      })
   }



}

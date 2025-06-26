import { Component, effect, inject,signal,Signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaService } from '../../services/materia.service';


@Component({
  selector: 'app-materias',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './materias.component.html',
  styleUrl: './materias.component.css'
})
export class MateriasComponent {
   private _http = inject(MateriaService);
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
  
}

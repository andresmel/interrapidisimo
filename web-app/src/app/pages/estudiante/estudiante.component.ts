import { Component , inject, signal,effect} from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstudianteService } from '../../services/estudiante.service';
import { toSignal } from '@angular/core/rxjs-interop';
import { authStore, usuario } from '../../store/auth-store';
import { of } from 'rxjs';
import { computed } from '@angular/core';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estudiante.component.html',
  styleUrl: './estudiante.component.css'
})
export class EstudianteComponent {

  clase= signal<any[]>([]);
  private _http = inject(EstudianteService);
  clases = signal<any[]>([]);
  loading = signal(false);
  refrescar=signal(0);
  clasesEstudiantes = signal<any[]>([]);
  estudiantes = signal<EstudianteConClases[]>([]);
  estudiantesByclase = signal<any[]>([]);

   res=effect(() => {


      const u = usuario();
      this.refrescar(); // marcar dependencia
      if (!u) return;
      this._http.getClases(u.id).subscribe({
        next: (res) =>{

          let response=res.data;
          if(response==null){
            this.clases.set([]);
          }else{
               this.clases.set(response);
          }
        },
        error: (error) => {
          console.error('Error al obtener las clases:', error);
          this.clases.set([])
        }
      });



      this._http.getCLasesEstudiantes(u.id).subscribe({
        next: (res) =>{
           const agrupado: { [nombre: string]: EstudianteConClases } = {};
           for (const item of res.data) {
               const nombre = item.estudiante;

               if (!agrupado[nombre]) {
                   agrupado[nombre] = {
                   estudiante: nombre,
                   clases: []
                  };
               }

               agrupado[nombre].clases.push({
               materia: item.materia,
               profesor: item.profesor
               });
           }

           this.estudiantes.set(Object.values(agrupado));
           },
           error: (error) => {
           console.error('Error al obtener las clases:', error);
           this.clasesEstudiantes.set([])
           }
          });

          this._http.getEstudiantesByClase(u.id).subscribe({
             next: (res) =>{
                 console.log(res)
                 if(res.data!=null){
                      this.estudiantesByclase.set(res.data)
                 }else{
                      this.estudiantesByclase.set([])
                 }

             },
             error:(error)=>{
              this.estudiantesByclase.set([])
                 console.log(error)
             }
           });

  });



        actualizar(){
           this.refrescar.update(v => v + 1);
        }

}


interface Clase {
  idClase: number;
  estudiante: string;
  materia: string;
  profesor: string;
}

interface EstudianteConClases {
  estudiante: string;
  clases: {
    materia: string;
    profesor: string;
  }[];
}


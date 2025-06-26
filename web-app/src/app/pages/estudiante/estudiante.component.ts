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
  private _http = inject(EstudianteService);
  clase= signal<any[]>([]);
  private http = inject(EstudianteService);
  clases = signal<any[]>([]);
  loading = signal(false);
  refrescar=signal(0);
 
  ngOnInit() {
    
  }

   res=effect(() => {
      const u = usuario();
      this.refrescar(); // marcar dependencia
      if (!u) return;

     

      this.http.getClases(u.id).subscribe({
        next: (res) =>{
         
          let response=res.data;
             console.log(response);
          this.clases.set(response);
        },
        error: (error) => {
          console.error('Error al obtener las clases:', error);
          this.clases.set([])
        } 
      });
    });

  actualizar(){
    this.refrescar.update(v => v + 1);
  }

}
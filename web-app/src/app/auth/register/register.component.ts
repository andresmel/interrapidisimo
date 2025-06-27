import { Component, inject } from '@angular/core';
import { FormControl, Validators, FormBuilder as fb, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../Auth.service';
import { Router } from '@angular/router';
import { authStore } from '../../store/auth-store';
import { HeaderAuthComponent } from '../shared/header-auth/header-auth.component';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule,HeaderAuthComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
private fb = inject(fb);
  private _http = inject(AuthService);
  private _route = inject(Router);

  formData = this.fb.group({
    nombre:new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });


  register() {
    if (this.formData.valid) {
      console.log(this.formData.value);
      this._http.postEstudiante(this.formData.value).subscribe({
        next: (response) => {
          if (response.data) {
            alert("Estudiante registrado correctamente");
          } else {
            alert('registro fallido');
          }
        },
        error: (error) => {
          alert('Error al registrar usuario: ' + error.error?.mensaje);

        }
      }); // <-- CIERRE CORRECTO DE subscribe
    } else {
      console.log('Formulario inválido');
    }
  }



}

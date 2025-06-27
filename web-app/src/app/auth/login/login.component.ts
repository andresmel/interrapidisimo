
import { Component, inject } from '@angular/core';
import { FormControl, Validators, FormBuilder as fb, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../Auth.service';
import { Router } from '@angular/router';
import { authStore } from '../../store/auth-store';
import { HeaderAuthComponent } from './../shared/header-auth/header-auth.component';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule,HeaderAuthComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private fb = inject(fb);
  private _http = inject(AuthService);
  private _route = inject(Router);

  formData = this.fb.group({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });


  login() {
    if (this.formData.valid) {
      console.log(this.formData.value);
      this._http.postLogin(this.formData.value).subscribe({
        next: (response) => {
          console.log(response);
          console.log(response.data)
          authStore.setUsuario(response.data);
          if (response.data?.id>0) {
            this._route.navigate(['/dashboard']);
          } else {
            alert('Usuario o contraseña incorrectos');
          }
        },
        error: (error) => {
          alert('Error al iniciar sesión: ' + error.error?.mensaje);
          console.log(error)
        }
      }); // <-- CIERRE CORRECTO DE subscribe
    } else {
      console.log('Formulario inválido');
    }
  }



}

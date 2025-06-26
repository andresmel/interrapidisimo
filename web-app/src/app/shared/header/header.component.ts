import { Component, inject, OnInit } from '@angular/core';
import { usuario } from '../../store/auth-store';
import { CommonModule } from '@angular/common'; // ✅ importa esto
import { effect } from '@angular/core';
import { authStore } from '../../store/auth-store';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  private _route=inject(Router);
  usuario = usuario;
  auth= authStore; // Acceso al store de autenticación
  constructor() {}


   logEffect = effect(() => {
    console.log('Usuario actualizado en header:', this.usuario());
  });

  logout() {
    sessionStorage.removeItem('usuario');
    this.auth.clearUsuario(); // Actualiza el store
    this._route.navigate(['/login']); // Redirige al login
  }
  
}

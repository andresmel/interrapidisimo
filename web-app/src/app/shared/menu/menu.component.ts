import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
 private _route = inject(Router);

 estudiante(){
    this._route.navigate(['/dashboard/estudiante']);
 }

 materias(){
   this._route.navigate(['/dashboard/materias']);
 }
}

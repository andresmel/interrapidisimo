import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../../shared/header/header.component';
import { authStore } from '../../store/auth-store';

@Component({
  selector: 'app-layout-private',
  standalone: true,
  imports: [RouterOutlet,HeaderComponent],
  templateUrl: './layout-private.component.html',
  styleUrl: './layout-private.component.css'
})
export class LayoutPrivateComponent {
    constructor() {
      authStore.loadUsuarioFromSession();
    }
}

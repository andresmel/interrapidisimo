import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../../shared/header/header.component';
import { authStore } from '../../store/auth-store';
import { MenuComponent } from "../../shared/menu/menu.component";

@Component({
  selector: 'app-layout-private',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, MenuComponent,MenuComponent],
  templateUrl: './layout-private.component.html',
  styleUrl: './layout-private.component.css'
})
export class LayoutPrivateComponent {
    constructor() {
      authStore.loadUsuarioFromSession();
    }
}

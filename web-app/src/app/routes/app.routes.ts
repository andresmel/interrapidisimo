import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: 'login', loadComponent: () => import('../auth/login/login.component').then(m => m.LoginComponent) },
    {path: 'register', loadComponent: () => import('../auth/register/register.component').then(m => m.RegisterComponent) },
    {path: 'dashboard', loadComponent: () => import('../layouts/layout-private/layout-private.component').then(m => m.LayoutPrivateComponent),children: [
        {path: '', redirectTo: 'estudiante', pathMatch: 'full' },
        {path: 'estudiante', loadComponent: () => import('../pages/estudiante/estudiante.component').then(m => m.EstudianteComponent) },
        {path: 'materia', loadComponent: () => import('../pages/materias/materias.component').then(m => m.MateriasComponent) },
    ]},
    
    {path: 'dashAdmin', loadComponent: () => import('../layouts/layout-admin/layout-admin.component').then(m => m.LayoutAdminComponent) },

];

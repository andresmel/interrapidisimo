import { signal, computed } from '@angular/core';

export interface UsuarioDTO {
  id: number;
  nombre: string;
  email: string;
}


const _usuario = signal<UsuarioDTO | null>(null);


export const usuario = computed(() => _usuario());



export const authStore = {
 
  setUsuario: (dto: UsuarioDTO) => {
    sessionStorage.setItem('usuario', JSON.stringify(dto));
    _usuario.set(dto);
  },


  clearUsuario: () => {
    sessionStorage.removeItem('usuario');
    _usuario.set(null);
  },


  loadUsuarioFromSession: () => {
    const raw = sessionStorage.getItem('usuario');
    if (raw) {
      try {
        const dto: UsuarioDTO = JSON.parse(raw);
        _usuario.set(dto);
      } catch (e) {
        console.error('Error al parsear usuario guardado');
        sessionStorage.removeItem('usuario');
      }
    }
  }
};



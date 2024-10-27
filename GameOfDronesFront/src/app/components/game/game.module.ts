import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component'; // Ajuste o caminho se necessário

@NgModule({
  declarations: [GameComponent],
  imports: [CommonModule],
  exports: [GameComponent] // Adicione isso para exportar o GameComponent
})
export class GameModule { }

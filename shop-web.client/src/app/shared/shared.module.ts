import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [ReactiveFormsModule, FormsModule],
  providers: [],
  exports: [ReactiveFormsModule, FormsModule],
})
export class SharedModule {}

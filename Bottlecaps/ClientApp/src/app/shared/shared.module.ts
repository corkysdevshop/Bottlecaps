import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MaterialModule } from './material/material.module';


@NgModule({
	declarations: [
		FetchDataComponent,
	],
  imports: [
	  CommonModule,
	  MaterialModule
	],
	exports: [
	]
})
export class SharedModule { }

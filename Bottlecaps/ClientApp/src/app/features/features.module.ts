import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicFacingModule } from './public-facing/public-facing.module';

import { PrivateModule } from './private/private.module';

@NgModule({
	declarations: [
	],
  imports: [
	  CommonModule,
	  PublicFacingModule,
	  PrivateModule
	],
	exports: [
		PublicFacingModule
	]
})
export class FeaturesModule { }

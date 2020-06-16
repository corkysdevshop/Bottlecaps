import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap, Space } from '../../../../shared/models';
import { SpaceService } from '../space.service';

@Component({
  selector: 'app-space-area',
  templateUrl: './space-area.component.html',
  styleUrls: ['./space-area.component.css']
})
export class SpaceAreaComponent implements OnInit {

	spaceCaps: Bottlecap[];

  constructor(private spaceService: SpaceService) { }

	ngOnInit(): void {
		this.spaceService.getSpaceBottlecaps();
		this.spaceService.spacesChanged.subscribe(spaces => {
			this.spaceCaps = spaces.slice();
		})
  }

	placeBottlecap(title) {
		this.ctx = this.canvas.nativeElement.getContext('2d');
		this.ctx.arc(50, 50, 40, 0, 2 * Math.PI);
		this.ctx.stroke();
		//this.ctx.font = "30px Arial";
		this.ctx.fillText(title, 10, 50);
	}

	checkSpaces() {
		console.log("spaces in this.spaceService.spaceBottleCapCollection: ", this.spaceService.spaceBottleCapCollection);
		console.log("spaces in this.spaceCaps: ", this.spaceCaps);
	}

	renderText(space) {
		console.log("render Text: ");
	}
}

import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap, Space } from '../../../../shared/models';
import { SpaceService } from '../space.service';
import { CdkDrag } from '@angular/cdk/drag-drop';

@Component({
	selector: 'app-space-area',
	templateUrl: './space-area.component.html',
	styleUrls: ['./space-area.component.css']
})

export class SpaceAreaComponent implements OnInit {
	@ViewChild('spaceArea', {static:false}) canvas: ElementRef;
	spaceCaps: Bottlecap[];
	dragPosition = [];
  constructor(private spaceService: SpaceService) { }

	ngOnInit(): void {
		this.spaceService.spacesChanged.subscribe(spaces => {
			this.spaceCaps = [];
			console.log("111111111111111", spaces);
			this.loadPositions(spaces);
			this.spaceCaps = spaces.slice();
		}, (err) => { console.log("err: ", err); });
		this.spaceService.getSpaceBottlecaps();
  }

  // puts position objects into local array so they can be accessed in html cdkDragFreeDragPosition to set the position on load. 
	loadPositions(spaces: Bottlecap[]) {
		this.dragPosition = [];
		for (var i = 0; i < spaces.length; i++) {
      var posObj = { x: spaces[i].positionX, y: spaces[i].positionY };
			this.dragPosition.push(posObj);
		}
	}

  // figures out where bottlecap was moved to
	onDragEnded(event, bottlecap: Bottlecap, index) {
		console.log(event, bottlecap);
		var oldX = parseInt(bottlecap.positionX);
		var oldY = parseInt(bottlecap.positionY);
		var newX = event.distance.x;
		var newY = event.distance.y;
		var convertedX = oldX + newX;
		var convertedY = oldY + newY;
		this.updatePlaceinDB(Math.round(convertedX), Math.round(convertedY), bottlecap.bottlecapId);
		var posObj = { x: convertedX, y: convertedY };
		console.log("posObj: ", posObj);
		this.dragPosition.splice(index, 1, posObj);
		this.dragPosition[index] = posObj;
	}

  // sends new position to database
	updatePlaceinDB(x: number, y: number, spaceCapId: number) {
		const space = new Space();
		space.SpaceId = spaceCapId.toString();
		space.PositionX = x.toString();
		space.PositionY = y.toString();
		this.spaceService.updatePlace(space);
	}

  // END
  // HELPER METHODS FOR DEVELOPMENT
	checkSpaces(event) {
		//console.log("spaces in this.spaceService.spaceBottleCapCollection: ", this.spaceService.spaceBottleCapCollection);
		console.log("spaces in this.spaceCaps: ", this.spaceCaps);
		console.log("this.dragPosition: ", this.dragPosition)
	}
	resetPositions() {
		for (let space of this.spaceCaps) {
			this.updatePlaceinDB(10, 10, space.bottlecapId);
		}
	}
}

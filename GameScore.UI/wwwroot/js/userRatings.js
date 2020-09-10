
$("#submitRating").click(function () {
   var dataObject = JSON.stringify({
      Graphics: $("#graphicsSelect").val(),
      Gameplay: $("#gameplaySelect").val(),
      Sound: $("#soundSelect").val(),
      Narrative: $("#narrativeSelect").val(),
      GameId: $("#gameId").html()
   });
    
   $.ajax({
      url: '/Rate/Submit',
      data: dataObject,
      contentType: 'application/json',
      type: 'POST',
      success: function (data) {
         $("#scoreContainer").html(data);
      }
   });
});
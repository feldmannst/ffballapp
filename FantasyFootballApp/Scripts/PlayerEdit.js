// JavaScript source code

$(document).ready(function () {
    $('#PlayerTableContainer').jtable({
        title: 'PlayerTable',
        paging: true,
        pageSize: 50,
        actions: {
            listAction: '/Player/PlayerList',
            createAction: '/Player/CreatePlayer',
            updateAction: '/Player/UpdatePlayer',
            deleteAction: '/Player/DeletePlayer'
        },
        fields: {
            PlayerID: {
                key: true,
                list: false
            },
            PlayerName: {
                title: 'PlayerName',
                width: '30%',
            },
            Nickname: {
                title: 'Nickname',
                width: '25%',
                create: true,
                list: false,
                edit: true
            },
            PositionID: {
                title: 'Position',
                width: '10%',
                options: '/Player/GetPositions'
            },
            TeamID: {
                title: 'Team',
                width: '20%',
                options: '/Player/GetTeams'
            },
            Retired: {
                title: 'Retired',
                width: '10%',
                type: 'checkbox',
                values: { 'false': 'No', 'true': 'Yes' },
                defaultValue: 'false'
            }

        }
    });
    $('#LoadRecordsButton').click(function (e) {
        e.preventDefault();
        $('#PlayerTableContainer').jtable('load', {
            positiondd: $('#positiondd').val(),
            teamdd: $('#teamdd').val()
        });
    });

    $('#LoadRecordsButton').click();

    //$('#PlayerTableContainer').jtable('load');
});
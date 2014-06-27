// JavaScript source code

$(document).ready(function () {
    $('#TeamTableContainer').jtable({
        title: 'TeamTable',
        actions: {
            listAction: '/Team/TeamList',
            createAction: '/Team/CreateTeam',
            updateAction: '/Team/UpdateTeam',
            deleteAction: '/Team/DeleteTeam'
        },
        fields: {
            TeamID: {
                key: true,
                list: false
            },
            TeamName: {
                title: 'TeamName',
                width: '20%'
            },
            Abbreviation: {
                title: 'Abbreviation',
                width: '10%'
            },
            FirstName: {
                title: 'FirstName',
                width: '25%'
            },
            State: {
                title: 'State',
                width: '15%'
            },
            Conference: {
                title: 'Conference',
                width: '10%'
            },
            Division: {
                title: 'Division',
                width: '20%'
            }
        }
    });

    $('#TeamTableContainer').jtable('load');
});


package com.example.PPM.Service;

import java.util.List;


import com.example.PPM.Model.Project;

public interface ProjectService 
{

	public List<Project> Get();
	
	public void Save(Project project);
	
	public Project GetById(int id);
	
	public void Delete(int id);
}
